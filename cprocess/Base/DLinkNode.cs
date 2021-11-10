using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace cprocess
{
	public class DLinkNode : IEnumerable
	{
		public DLinkNode Prev { get; set; }
		public DLinkNode Next { get; set; }
		public Object Value { get; set; }

		public void AddAfter(DLinkNode node)
		{
			if (this.Next != null)
			{
				node.Next = Next;
				Next.Prev = node;
			} //else nothing;
			
			this.Next = node;
			node.Prev = this;
		}

		public void AddBefore(DLinkNode node)
		{
			if (this.Prev != null)
			{
				node.Prev = Prev;
				Prev.Next = node;
			} //else nothing;

			this.Prev = node;
			node.Next = this;
		}

		public void Del(DLinkNode node)
		{
			if (node.Prev == null)
			{
				node.Next.Prev = null;
				node.Next = null;
			}
			else if (node.Next == null)
			{
				node.Prev.Next = null;
				node.Prev = null;
			}
			else
			{
				node.Prev.Next = node.Next;
				node.Next.Prev = node.Prev;
				node.Prev = null;
				node.Next = null;
			}
		}

		public void Swap(DLinkNode node)
		{
			DLinkNode tempNode = new DLinkNode();

			if (this.Prev == node || this.Next == node)
			{
				DLinkNode frontNode, backNode;
				if (this.Next == node)
				{
					frontNode = this;
					backNode = node;
				}
				else
				{
					frontNode = node;
					backNode = this;
				}

				if (backNode.Next != null)
				{
					tempNode.Next = backNode.Next;
				} //else nothing

				if (frontNode.Prev != null)
				{
					frontNode.Prev.Next = backNode;
				}
				//if and else both
				backNode.Prev = frontNode.Prev;

				backNode.Next = frontNode;
				frontNode.Prev = backNode;

				if (tempNode.Next != null)
				{
					tempNode.Next.Prev = frontNode;
				}
				//if and else both
				frontNode.Next = tempNode.Next;
			}
			else
			{
				if (node.Prev != null)
				{
					tempNode.Prev = node.Prev;
				} //else nothing
				if (node.Next != null)
				{
					tempNode.Next = node.Next;
				} //else nothing


				if (this.Prev != null)
				{
					this.Prev.Next = node;
				}
				//if and else both
				node.Prev = this.Prev;

				if (this.Next != null)
				{
					this.Next.Prev = node;
				}
				//if and else both
				node.Next = this.Next;


				if (tempNode.Prev != null)
				{
					tempNode.Prev.Next = this;
				}
				//if and else both
				this.Prev = tempNode.Prev;

				if (tempNode.Next != null)
				{
					tempNode.Next.Prev = this;
				}
				//if and else both
				this.Next = tempNode.Next;
			}
		}

		public DLinkNode FindBy(Object data)
		{
			if (this.Value.Equals(data))
			{
				return this;
			}
			else
			{
				for (DLinkNode find = this; find.Prev != null; find = find.Prev)
				{
					if (find.Prev.Value.Equals(data))
					{
						return find.Prev;
					} //else continue
				}

				for (DLinkNode find = this; find.Next != null; find = find.Next)
				{
					if (find.Next.Value.Equals(data))
					{
						return find.Next;
					} //else continue
				}

				return new DLinkNode() { Value = "not find" };
			}
		}

		public IEnumerator GetEnumerator()
		{
			return new Enumerator(this);
		}

		public struct Enumerator : IEnumerator
		{
			private DLinkNode localDLN;
			private bool isFirst;

			public Enumerator(DLinkNode dLinkNode)
			{
				localDLN = dLinkNode;
				Current = dLinkNode;
				isFirst = true;
			}

			public object Current { get; set; }

			public bool MoveNext()
			{
				if (isFirst)
				{
					isFirst = false;
					return true;
				}
				else
				{
					if (((DLinkNode)Current).Next == null)
					{
						return false;
					}
					else
					{
						Current = ((DLinkNode)Current).Next;
						return true;
					}
				}
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}
		}
	}


	public class DLinkNode<T> : IEnumerable<DLinkNode<T>>
	{
		public DLinkNode<T> Prev { get; set; }
		public DLinkNode<T> Next { get; set; }
		public T Value { get; set; }

		public bool IsHead { get => this.Prev == null; }
		public bool IsTail { get => this.Next == null; }

		public void AddAfter(DLinkNode<T> node)
		{
			if (!IsTail)
			{
				node.Next = this.Next;
				this.Next.Prev = node;
			} 
			//if and else both
			this.Next = node;
			node.Prev = this;
		}

		public void AddBefore(DLinkNode<T> node)
		{
			if (!IsHead)
			{
				node.Prev = this.Prev;
				this.Prev.Next = node;
			} 
			//if and else both
			this.Prev = node;
			node.Next = this;
		}

		public void Del(DLinkNode<T> node)
		{
			if (node.Prev == null)
			{
				node.Next.Prev = null;
				node.Next = null;
			}
			else if (node.Next == null)
			{
				node.Prev.Next = null;
				node.Prev = null;
			}
			else
			{
				node.Prev.Next = node.Next;
				node.Next.Prev = node.Prev;
				node.Prev = null;
				node.Next = null;
			}
		}

		public void Swap(DLinkNode<T> node)
		{
			DLinkNode<T> tempNode = new DLinkNode<T>();

			if (this.Prev == node || this.Next == node)
			{
				DLinkNode<T> frontNode, backNode;
				if (this.Next == node)
				{
					frontNode = this;
					backNode = node;
				}
				else
				{
					frontNode = node;
					backNode = this;
				}

				if (backNode.Next != null)
				{
					tempNode.Next = backNode.Next;
				} //else nothing

				if (frontNode.Prev != null)
				{
					frontNode.Prev.Next = backNode;
				}
				//if and else both
				backNode.Prev = frontNode.Prev;

				backNode.Next = frontNode;
				frontNode.Prev = backNode;

				if (tempNode.Next != null)
				{
					tempNode.Next.Prev = frontNode;
				}
				//if and else both
				frontNode.Next = tempNode.Next;
			}
			else
			{
				if (node.Prev != null)
				{
					tempNode.Prev = node.Prev;
				} //else nothing
				if (node.Next != null)
				{
					tempNode.Next = node.Next;
				} //else nothing


				if (this.Prev != null)
				{
					this.Prev.Next = node;
				}
				//if and else both
				node.Prev = this.Prev;

				if (this.Next != null)
				{
					this.Next.Prev = node;
				}
				//if and else both
				node.Next = this.Next;


				if (tempNode.Prev != null)
				{
					tempNode.Prev.Next = this;
				}
				//if and else both
				this.Prev = tempNode.Prev;

				if (tempNode.Next != null)
				{
					tempNode.Next.Prev = this;
				}
				//if and else both
				this.Next = tempNode.Next;
			}
		}

		public List<DLinkNode<T>> FindBy(T data)
		{
			List<DLinkNode<T>> list = new List<DLinkNode<T>>();

			if (this.Value.Equals(data))
			{
				list.Add(this);
				return list;
			}
			else
			{
				for (DLinkNode<T> find = this; find.Prev != null; find = find.Prev)
				{
					if (find.Prev.Value.Equals(data))
					{
						list.Add(find.Prev);
						return list;
					} //else continue
				}

				for (DLinkNode<T> find = this; find.Next != null; find = find.Next)
				{
					if (find.Next.Value.Equals(data))
					{
						list.Add(find.Next);
						return list;
					} //else continue
				}

				return list;
			}
		}

		public IEnumerator<DLinkNode<T>> GetEnumerator()
		{
			return new Enumerator(this);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public struct Enumerator : IEnumerator<DLinkNode<T>>
		{
			private DLinkNode<T> localDLN;
			private bool isFirst;

			public Enumerator(DLinkNode<T> dLinkNode)
			{
				localDLN = dLinkNode;
				Current = dLinkNode;
				isFirst = true;
			}

			public DLinkNode<T> Current { get; set; }

			object IEnumerator.Current => Current;

			public void Dispose()
			{
				
			}

			public bool MoveNext()
			{
				if (isFirst)
				{
					isFirst = false;
					return true;
				}
				else
				{
					if (Current.IsTail)
					{
						return false;
					}
					else
					{
						Current = Current.Next;
						return true;
					}
				}
			}

			public void Reset()
			{
				throw new NotImplementedException();
			}
		}
	}

	public static class DLinkNodeExtension
	{
		public static DLinkNode<int> Max(this DLinkNode<int> sourceNode)
		{
			DLinkNode<int> findMaxNode = sourceNode;

			for (DLinkNode<int> upNode = sourceNode; upNode.Prev != null; upNode = upNode.Prev)
			{
				if (upNode.Prev.Value > findMaxNode.Value)
				{
					findMaxNode = upNode.Prev;
				}
			}
			for (DLinkNode<int> dnNode = sourceNode; dnNode.Next != null; dnNode = dnNode.Next)
			{
				if (dnNode.Next.Value > findMaxNode.Value)
				{
					findMaxNode = dnNode.Next;
				}
			}

			return findMaxNode;
		}
	}
}
